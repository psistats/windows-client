import sys
import os

artifact = "ARTIFACT_ID=psistats-client"
version = "VERSION=" + f.open("VERSION").read()

with f.open("env.properties", "w")):
    f.write(artifact + "\n")
    f.write(version)
