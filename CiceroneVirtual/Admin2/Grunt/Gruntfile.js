'use strict';

module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    // Metadata.
    
    pkg: grunt.file.readJSON('package.json'),
    clean: ["Debug/*", "Release/*"],
    includes: {
        files:{
            src:['../Source/App/www/index.html'],
            dest: 'lib',
            flatten: true,
        }
    },
  });

  // These plugins provide necessary tasks.
  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-copy');
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-nodeunit');
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-contrib-htmlmin');
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-includes');
  grunt.loadNpmTasks('grunt-mkdir');
  grunt.loadNpmTasks('grunt-htmlhint');
  grunt.loadNpmTasks('grunt-exec');
  grunt.loadNpmTasks('grunt-replace');

  // Default task.
  grunt.registerTask('default', ['clean', 'replace:source', 'copy:source', 'mkdir:lib', 'mkdir:dist', 'includes', 'concat:app', 'concat:utils', 'copy:dist', 'jshint:core', 'uglify', 'htmlhint:lib', 'htmlmin:dist', 'cssmin:dist']);

  grunt.registerTask('teste', ['clean', 'replace:source']);
            
  grunt.registerTask('default2', ['clean', 'copy:source', 'mkdir:lib', 'mkdir:dist', 'includes', 'concat:app', 'concat:utils', 'copy:dist', 'jshint:core', 'htmlhint:lib', 'cssmin:dist']);
    
  grunt.registerTask('phonegap:create', ['mkdir:deploy', 'exec:createProject', 'copy:deploy', 'copy:config', 'exec:addDependencies', 'copy:splash']);
  grunt.registerTask('phonegap:update', ['copy:deploy', 'copy:update']);
};
