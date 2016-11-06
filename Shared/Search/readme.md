# IndexerWatcher.csx

This file needs a reference to `Microsoft.Azure.Search`, in order to get that reference the following needs to be added to the `project.json` of the calling function.

~~~ javascript
{
  "frameworks": {
    "net46":{
      "dependencies": {
        "Microsoft.Azure.Search": "1.1.3"
      }
    }
   }
}
~~~

