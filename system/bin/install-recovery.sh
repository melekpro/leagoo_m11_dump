#!/system/bin/sh
if ! applypatch -c EMMC:/dev/block/platform/bootdevice/by-name/recovery:12676000:366b3b4a9a73312a6be8571651edffd87d0c0c15; then
  applypatch -b /system/etc/recovery-resource.dat EMMC:/dev/block/platform/bootdevice/by-name/boot:8340384:9513b47093071ffc810f971e8b397ce7e008f09a EMMC:/dev/block/platform/bootdevice/by-name/recovery 366b3b4a9a73312a6be8571651edffd87d0c0c15 12676000 9513b47093071ffc810f971e8b397ce7e008f09a:/system/recovery-from-boot.p && log -t recovery "Installing new recovery image: succeeded" || log -t recovery "Installing new recovery image: failed"
else
  log -t recovery "Recovery image already installed"
fi
