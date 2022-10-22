# Hard Drives

## Metadata Gathering
```bash
hdparm -iI /dev/sdc > hdparm.txt
smartctl -x -j -d sat,16 /dev/sdc > smartctl.json       # JSON-formatted "smartctl" output.
smartctl -x -d sat,16 /dev/sdc > smartctl.txt           # Normal "smartctl" output.
fdisk -l /dev/sdc > fdisk.txt                           # Get a list of partitions.
file -s /dev/sdc* > magic.txt                           # Identify what's in each partition.
ntfsls -vRal /dev/sdc2 > ntfsls-sdc2.txt                # Get a basic list of the contents.
```

## Getting USB Information
```bash
# This works on Linux 5.19.16-200.fc36.x86_64 for USB storage devices.
function dev_usb_info {
    local DEV
    for DEV in $@
    do
        local USB_NODE=$(readlink -f /sys/dev/block/$(stat -c '%Hr:%Lr' ${DEV})/../../../../../../)
        local BUS_DEV=$(cat ${USB_NODE}/busnum):$(cat ${USB_NODE}/devnum)
        lsusb -s ${BUS_DEV} -v
    done
}
```
