precision mediump float;

varying vec2 v_texcoord0;
uniform sampler2D aTexture0;
uniform sampler2D aTexture1;
uniform sampler2D aTexture2;
uniform sampler2D aTexture3;
uniform float deltas;
uniform float deltah;
uniform int isBrightness;
uniform int isContrast;
uniform int isHsv;

void main(){
  vec4 src = texture2D(aTexture0, v_texcoord0);
  float r,g,b;
  float pix05=0.5/255.0;
  r=src.r;
  g=src.g;
  b=src.b;

  if(isBrightness==1){
  r=texture2D(aTexture1,vec2(r+pix05,1.0)).r;
  g=texture2D(aTexture1,vec2(g+pix05,1.0)).g;
  b=texture2D(aTexture1,vec2(b+pix05,1.0)).b;
  }

    if(isContrast==1){
    r=texture2D(aTexture3,vec2(r+pix05,1.0)).r;
    g=texture2D(aTexture3,vec2(g+pix05,1.0)).g;
    b=texture2D(aTexture3,vec2(b+pix05,1.0)).b;
    }

if(isHsv==1){
      float mixRGB, maxRGB, delta,h,s,v;
      mixRGB = min( r, min( g, b ));
      maxRGB = max( r, max( g, b ));
      v = maxRGB;               // v
      delta = maxRGB - mixRGB;
      if(delta == 0.0)
      {
          s = 0.0;
          h = 0.0;
      }else{
        if( maxRGB != 0.0 ){
          s = delta*255.0 / maxRGB;       // s

       int h_value;
       if( r == maxRGB ){
       h_value = int(( g - b ) * 60.0 / delta);     // between yellow & magenta
       }
       else if( g == maxRGB ){
        h_value = int(120.0 + ( b - r ) * 60.0 / delta); // between cyan & yellow
       } else{
       h_value =int( 240.0 + ( r - g ) * 60.0 / delta); // between magenta & cyan
        }
       if( h_value < 0 ){
       h_value += int(360.0);
       }
       h = float(h_value);
      } else {
          s = 0.0;
          h = -1.0;
      }
        }
         h = h + deltah;
        if(h>=360.0){
           h=h-360.0 ;
        }else{
          if(h<0.0){
           h=h+360.0;
        }
        }
          s = s * deltas;
          s=clamp(s, 0.0, 255.0);
          v =texture2D(aTexture2,vec2(v+pix05,1.0)).r;
              int i;
              float f, p, q, t;
              if( s == 0.0 )
              {
                  r =g=b= v;
              }else{
              float h1 = h / 60.0;           // sector 0 to 5
              float s1 = s / 255.0;
              i = int(h1);
              f = h1 - float(i);          // factorial part of h
              p = v * ( 1.0 - s1 );
              q = v * ( 1.0 - s1 * f );
              t = v * ( 1.0 - s1 * ( 1.0 - f ) );
             if(i==0){
                      r = v;
                      g = t;
                      b = p;
                      }else if(i==1){
                      r = q;
                      g = v;
                     b = p;
                     } else if(i==2){
                       r = p;
                       g = v;
                       b = t;
                     }else if(i==3){
                      r = p;
                      g = q;
                      b = v;
                     }else if(i==4){
                       r = t;
                       g = p;
                       b = v;
                     }else{
                        r = v;
                        g = p;
                        b = q;
                     }
              }
              }
                gl_FragColor = vec4(r,g,b,src.a);

}