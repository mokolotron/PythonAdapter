# PythonAdapter
Class allow to execute python script from C# project

# Usage 
 ```
 PythonAdapter python = new PythonAdapter(@"path/to/python/interpreter/python.exe");
 python.Execute(@"path/to/python/script/script.py", string[] arr_arguments);
```
