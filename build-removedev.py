import sys
import os

if 'NEW_VERSION' not in os.environ:
    print "[ERROR] NEW_VERSION environment variable not set."
    sys.exit(1)

with open("VERSION") as f:
    OLD_VERSION = f.read()
    
VERSION = OLD_VERSION.replace("-dev", "")

with open("sonar-project.properties") as f:
    contents = f.read()
    contents = contents.replace("sonar.projectVersion=" + OLD_VERSION, "sonar.projectVersion=" + VERSION)
    
with open("sonar-project.properties", "w") as f:
    f.write(contents)
    
with open("VERSION", "w") as f:
    f.write(VERSION)
    


