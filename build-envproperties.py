import sys
import os

artifact = "ARTIFACT_ID=psistats-client"
version = "VERSION=" + open("VERSION").read()
build_number = "BUILD_NUMBER=" + os.environ['BUILD_NUMBER']

with open("env.properties", "w") as f:
    f.write(artifact + "\n")
    f.write(version + "\n")
    f.write(build_number)
    
