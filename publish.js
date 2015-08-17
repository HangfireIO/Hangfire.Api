var ghpages = require('gh-pages');
var path = require('path');

ghpages.publish(path.join(__dirname, 'Hangfire.Api/help'), {
  logger: function(message) {
    console.log(message);
  },
  add: true,
});