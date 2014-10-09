import sys
import os

artifact = "ARTIFACT_ID=psistats-client"
version = "VERSION=" + f.open("VERSION").read()
build_number = "BUILD_NUMBER=" + os.environ['BUILD_NUMBER']

with f.open("env.properties", "w")):
    f.write(artifact + "\n")
    f.write(version + "\n")
    f.write(build_number)
    
