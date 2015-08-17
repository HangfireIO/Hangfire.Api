var ghpages = require('gh-pages');
var path = require('path');
var msbuild = require('msbuild');

var publish = function () {
  console.log("Publishing the project...");
  ghpages.publish(path.join(__dirname, 'Hangfire.Api/help'), {
    logger: function(message) {
      console.log(message);
    },
    add: true,
  });
};

var build = new msbuild(publish); 
build.sourcePath = path.join(__dirname, 'Hangfire.Api.sln');
build.configuration = 'debug';
build.publishProfile='';

console.log("Building the project...");
build.build();
