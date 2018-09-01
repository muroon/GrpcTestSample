# Unity Grpc Test Sample

## Description

This is a sample whchi use grpc in Unity.

## Included

- [grpc](https://github.com/grpc/grpc/tree/master/src/csharp/experimental#unity)

## Android

You can build in Unity.

## iOS

After exporting Xcode project, The following work is necessary in Xcode.

### Enable Bitcode : false

- Build Settings > Enable Bitcode
- Set "No"

### Including zlib library

- Build Phases > Link Binary With Libraries > +
- Search "libz"
- Choose libz.1.2.xx.tbd (ex libz.1.2.11.tbd)
- Push Add Button

