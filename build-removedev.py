import sys

with open("VERSION") as f:
    VERSION = f.read()
    
NEW_VERSION = VERSION.replace("-dev", "")

with open("sonar-project.properties") as f:
    contents = f.read()
    contents = contents.replace("sonar.projectVersion=" + VERSION, "sonar.projectVersion=" + NEW_VERSION)
    
with open("sonar-project.properties", "w") as f:
    f.write(contents)
    
with open("VERSION", "w") as f:
    f.write(NEW_VERSION)


