# TaskIt.Dotnet.Versions

Simple dotnet tool for setting / modifying version tags in .csproj files.
This tool overwrites / modifies the following tags in your .csproj files (if present):
- `Version`
- `AssemblyVersion`
- `FileVersion`

This tool supports [semantic versioning](https://semver.org/) for the Version Tag.
`VersionPrefix` and `VersionSuffix` tags will not be processed.

## Installation
Like all dotnet tools this tool can be used on a project / solution level (simply add the nuget dependency) or be installed as a global tool.
Simply use the following commmand:<br/>
`dotnet tool install --global TaskIt.Dotnet.Versions`

## Usage

Simply call:<br/>
`dotnet versions <operation> <parameters>`

### Supported operations

#### Set
`set` will _overwrite_ the version tags in the .csproj file(s).<br/>

Parameter | Required | Description |
----------|------------ |------------ |
`-v`<br/> `--version` | yes | string - The new Version to set.<br/> The version string must be [semver 2.0](https://semver.org/) compliant. <br/>In extension of the specification you can use wildcards (`*`) to _spare_ some digits in the version string. Wildcards apply only to the `major`, `minor` and `patch` versions and will not be overwritten.<br/> For `AssemblyVersion` and `FileVersion` tags, only the `major`, `minor`and `patch` versions will be overwritten|

See the examples section for more information. 

#### Modify
`mod` will increment / modify the versions tags in the .csproj files.

Parameter | Required | Description |
----------|------------ |------------ |
`-v`<br/> `--version` | no | string - The pattern in whith the Version (`major`.`minor`.`patch`) will be modified<br/> You can use wildcards (`*`) to _spare_ some digits in the version string.<br/>Any digit specified will be added to the correspondending `major`, `minor` or `patch` version.<br> A value of `0` will be set as the correspondending `major`, `minor` or `patch` version.<br/> The same applies to `AssemblyVersion` and `FileVersion` tags. |
`-p`<br/> `--semverpattern` | no | string - regular expression for finding the semantic part of the version which should be modified (don't forget the caapture group)| 
`-m`<br/> `--semvermodifier` | no | int - summand which will be added to the captured number |

See the examples section for more information. 

#### Common Paramters

Parameter | Required | Description |
----------|------------ |------------ |
`-s`<br/> `--source` | no | Fully qualified solution (.sln) or project (.csproj) file.<br/> If its a solution file, all projects in all subdirectories will be processed.<br/> If omitted, the current directory will be searched for a solution file. If present, all projects in all subdirectories will be processed. |
`-b`<br/> `--backup` | no | true / false (default = false)<br/>If set, a backup of the processed .csproj files will be created.<br/> Filename: _yourproject.csproj.backup_ | 


## Examples

### Set

call| original version | modified version |
-------- | -------- | -------- |
dotnet versions set 1.1.0 | `<Version>0.9.23</Version>`<br/>`<AssemblyVersion>0.9.23.1</AssemblyVersion>` | `<Version>1.1.0</Version>`<br/>`<AssemblyVersion>1.1.0.1</AssemblyVersion>` |
dotnet versions set 1.1.1-RC1 | `<Version>1.1.0</Version>`<br/>`<AssemblyVersion>1.1.0.0</AssemblyVersion>` | `<Version>1.1.1-RC1</Version>`<br/>`<AssemblyVersion>1.1.1.0</AssemblyVersion>` |
dotnet versions set *.2.0 | `<Version>2.1.1-RC5</Version>`<br/>`<AssemblyVersion>2.1.1.0</AssemblyVersion>` | `<Version>2.2.0</Version>`<br/>`<AssemblyVersion>2.2.0.0</AssemblyVersion>` |

The idea ist an adaption of the maven versions plugin used in the java / maven ecosystem This tool was inspired by the mavon versons plugin