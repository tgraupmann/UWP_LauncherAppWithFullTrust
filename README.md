# UWP_LauncherAppWithFullTrust

## Repository Description

```
UWP project with a launcher that launches an app with full trust
```

## Overview

MS Store builds are sandboxed with security preventing code from executing outside of the original process.

In some cases, you need execution to work outside of the main process to access a service or to control RGB hardware.

Launching an application with fulltrust allows this scenario. A full trust application will be able to access the Win32 APIs necessary to control RGB hardware.

This project is setup with a Windows Application Packaging Project that references two UWP projects. The UWP launcher project launches a UWP game project with full trust.

## Screenshots

**The UWP launcher app**

![image_1](images/image_1.png)

**The UWP game app**

![image_2](images/image_2.png)
