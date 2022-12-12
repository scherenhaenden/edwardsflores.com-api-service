#!/bin/bash
echo "Zipping release"

cd EdwardSFlores.Service
ls -ali
zip -r release.zip release
cp release.zip ../
ls -ali
cd ..
