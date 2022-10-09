

/*
{
  "kind": "codemodel",
  "version": { "major": 2, "minor": 4 },
  "paths": {
    "source": "/path/to/top-level-source-dir",
    "build": "/path/to/top-level-build-dir"
  },
  "configurations": [
    {
      "name": "Debug",
      "directories": [
        {
          "source": ".",
          "build": ".",
          "childIndexes": [ 1 ],
          "projectIndex": 0,
          "targetIndexes": [ 0 ],
          "hasInstallRule": true,
          "minimumCMakeVersion": {
            "string": "3.14"
          },
          "jsonFile": "<file>"
        },
        {
          "source": "sub",
          "build": "sub",
          "parentIndex": 0,
          "projectIndex": 0,
          "targetIndexes": [ 1 ],
          "minimumCMakeVersion": {
            "string": "3.14"
          },
          "jsonFile": "<file>"
        }
      ],
      "projects": [
        {
          "name": "MyProject",
          "directoryIndexes": [ 0, 1 ],
          "targetIndexes": [ 0, 1 ]
        }
      ],
      "targets": [
        {
          "name": "MyExecutable",
          "directoryIndex": 0,
          "projectIndex": 0,
          "jsonFile": "<file>"
        },
        {
          "name": "MyLibrary",
          "directoryIndex": 1,
          "projectIndex": 0,
          "jsonFile": "<file>"
        }
      ]
    }
  ]
}
*/