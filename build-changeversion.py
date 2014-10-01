import sys
import glob
import re

NEW_VERSION = sys.argv[1]

with open('VERSION') as f:
    VERSION=f.read()
    

print NEW_VERSION
print VERSION

def set_assemblyinfo_version(version):

    aLineRe = "[AssemblyVersion|AssemblyFileVersion]\(\"([\.0-9]+)\"\)"
    
    for name in glob.glob("./*/Properties/AssemblyInfo.cs"):
        print "Working on " + name
        
        new_file = []
        
        with open(name) as f:
            for line in f.readlines():
                if line.startswith("//") != True:
                    results = re.search(aLineRe, line)
                    if (results != None):
                        line = line.replace(results.group(1), version)
                        
                new_file.append(line)
        
        with open(name, "w") as f:
            f.write("".join(new_file))
            
def set_version_file(version):
    print "Working on VERSION file"
    with open("VERSION", "w") as f:
        f.write(version + "-dev")
        
def set_sonar_file(version):
    with open("sonar-project.properties") as f:
        new_file = []
        for line in f.readlines():
            results = re.search("sonar\.projectVersion\=([\.0-9]+)", line)
            if (results != None):
                line = line.replace(results.group(1), version + "-dev")
            new_file.append(line)
    
    with open("sonar-project.properties", "w") as f:
        f.write("".join(new_file))
        
def set_manifest_version(version):
    for name in glob.glob("./*/app.manifest"):
        with open(name) as f:
            print "Working on " + name
            new_file = []
            for line in f.readlines():
                results = re.search("assemblyIdentity version\=\"([\.0-9]+)\"", line)

                if results != None:
                    line = line.replace(results.group(1), version)
                    
                new_file.append(line)
        
        with open(name, "w") as f:
            f.write("".join(new_file))

def set_version_wxs_file(version):
    files = [
        "Bootstrapper/Bundle.wxs",
        "Psistats.Installer/Product.wxs"
    ]
    
    for file in files:
        with open(file) as f:
            print "Working on " + file
            new_file = []
            for line in f.readlines():
                results = re.search("\sVersion\=\"([\.0-9]+)\"", line)
                
                if results != None:
                    line = line.replace(results.group(1), version)
                    
                new_file.append(line)
                
        
        with open(file, "w") as f:
            f.write("".join(new_file))
 
def set_csproj_file(version):
    files = [
        "PsistatsApp/App.csproj"
    ]
    
    for name in files:
        with open(name) as f:
            print "Working on " + name
            new_file = []
            for line in f.readlines():
                results = re.search("\<ApplicationVersion\>([\.0-9]+)\<\/ApplicationVersion\>", line)
                if results != None:
                    line = line.replace(results.group(1), version)
                    
                new_file.append(line)
                
set_manifest_version(NEW_VERSION)
set_version_file(NEW_VERSION)        
set_assemblyinfo_version(NEW_VERSION)
set_version_wxs_file(NEW_VERSION)
set_csproj_file(NEW_VERSION)
set_sonar_file(NEW_VERSION)