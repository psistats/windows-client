import sys
import glob
import re

NEW_VERSION = sys.argv[1]

with open('VERSION') as f:
    VERSION=f.read()
    

print NEW_VERSION
print VERSION

def set_assemblyinfo_version(version):

    aLineRe = "AssemblyVersion|AssemblyFileVersion\(\"([\.0-9]+)\"\)"
    aVersionRe = "(\d\.\d\.\d)"
    
    print "Changing version numbers in AssemblyInfo.cs files"
    
    for name in glob.glob("./*/Properties/AssemblyInfo.cs"):
        print "Working on " + name
        
        new_file = []
        
        with open(name) as f:
            for line in f.readlines():
                if line.startswith("//") != True:
                    reProg = re.compile(aLineRe)
                    result = reProg.search(line)
                    if (result != None):
                        line = re.sub(aVersionRe, NEW_VERSION, line)
                new_file.append(line)
        
        with open(name, "w") as f:
            f.write("".join(new_file))
            
def set_version_file(version):
    print "Working on VERSION file"
    with open("VERSION", "w") as f:
        f.write(version)
        
def set_manifest_version(version):
    for name in glob.glob("./*/app.manifest"):
        with open(name) as f:
            print "Working on " + name
            new_file = []
            for line in f.readlines():
                results = re.search("assemblyIdentity version\=\"([\.0-9]+)\"", line)
                
                if results != None:
                    line = line.replace(results.group[0], version)
                new_file.append(line)
        
        with open(name, "w") as f:
            f.write("".join(new_file))

set_manifest_version(NEW_VERSION)
set_version_file(NEW_VERSION)        
set_assemblyinfo_version(NEW_VERSION)