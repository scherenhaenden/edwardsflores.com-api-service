#!/bin/bash
echo "Zipping release"


ls -ali
zip -r release.zip release
cp release.zip ../
ls -ali
cd ..
