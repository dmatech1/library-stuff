# VHS Tapes

I would like to convert a bunch of old VHS tapes to modern file formats.  I don't care much for degrading analog tapes, and I have the hardware needed to get rid of them.

# Plan
The venerable [ffmpeg](https://www.ffmpeg.org/) project can do a lot of the work, but there are a few things missing.  I'll be capturing and parsing the [VBI](https://en.wikipedia.org/wiki/Vertical_blanking_interval) data using the [ZVBI](http://zapping.sourceforge.net/ZVBI/) library as the audio and video are captured.  I will need to make sure that audio, video, and caption data remain synchronized even after 8 hours of continuous running, and that might require some modification of ffmpeg itself.

# Video
The selection of appropriate settings for video will require some experimentation.  Modern formats make it difficult to preserve the interlaced nature of the source video, so I'll see what level of deinterlacing I can do in real time.  The best technique is apparently "yadif", but it uses a lot of processing power.  The VHS source data will have a lot of noise, so I'll probably want to reduce the noise a little bit before the stream of fields hits the compressor (and possibly the deinterlacer).  For the h.264 compression, I'll probably want to use [x264](https://www.videolan.org/developers/x264.html) instead of hardware compression due to the enhanced quality, but only if I have the resources.

* Noise Reduction
  * [Adaptive Temporal Averaging Denoiser](https://ffmpeg.org/ffmpeg-filters.html#atadenoise)
  * [Denoise frames using Block-Matching 3D algorithm](https://ffmpeg.org/ffmpeg-filters.html#toc-bm3d)
  * [Denoise frames using 2D DCT (frequency domain filtering)](https://ffmpeg.org/ffmpeg-filters.html#toc-dctdnoiz)
  * [Denoise frames using 3D FFT](https://ffmpeg.org/ffmpeg-filters.html#fftdnoiz)
  * [High precision/quality 3D denoise filter](https://ffmpeg.org/ffmpeg-filters.html#toc-hqdn3d-1)
  * [Denoise frames using Non-Local Means algorithm](https://ffmpeg.org/ffmpeg-filters.html#toc-nlmeans-1)
  * [Overcomplete Wavelet denoiser](https://ffmpeg.org/ffmpeg-filters.html#toc-owdenoise)
  * [Wavelet based denoiser](https://ffmpeg.org/ffmpeg-filters.html#toc-vaguedenoiser)

# Hardware
The hardware I'm currently using is two secondhand [VIDBOX NW03](https://www.linuxtv.org/wiki/index.php/Honestech_Vidbox_NW03) devices using eMPIA [em28xx](https://www.linuxtv.org/wiki/index.php/Em28xx_devices) chips.  They're identical, so there's no way to differentiate them aside from by USB port.

```
# Run "lsusb.py -c -i -I" to see the topology.
# /sys/bus/usb/devices/usb3/3-4/3-4:1.0/video4linux/video1/             /dev/video1
# /sys/bus/usb/devices/usb3/3-4/3-4:1.0/video4linux/vbi1/               /dev/vbi1
# /sys/bus/usb/devices/usb3/3-4/3-4:1.1/sound/card2/pcmC2D0c/           hw:2,0
#                           ^^^ Port
```

# Other Efforts
* The [VHS to iTunes Compatible MP4](https://idle.run/vhs-convert) page from 2016 describes settings used under Windows with ffmpeg to convert VHS tapes at acceptable quality.  No mention is made of closed captions, and it is for PAL, not NTSC.  The actual [GitHub project](https://github.com/idlerun/vhs-convert/blob/master/README.md) has more details and includes settings related to noise reduction.
