'use strict';

module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    // Metadata.
    
    pkg: grunt.file.readJSON('package.json'),
    clean: ["Deploy/Debug/*", "Deploy/Release/*"],
    copy: {
        template: {
            files: [
              // includes files within path
              {expand: true, cwd: '../Source/Template2/images', src: ['**'], dest: 'Deploy/Debug/www/images'},
              {expand: true, cwd: '../Source/Template2/libs', src: ['**'], dest: 'Deploy/Debug/www/libs'},
              {expand: true, cwd: '../Source/Template2/ui', src: ['**'], dest: 'Deploy/Debug/www/ui'},
              {expand: true, cwd: '../Source/Template2', src: ['index.html'], dest: 'Deploy/Debug/www', filter: 'isFile'},
              {expand: true, cwd: '../Source/Template2', src: ['app.js'], dest: 'Deploy/Debug/www', filter: 'isFile'},
            ],
        },
        iosDebug: {
            files: [
              // includes files within path
              {expand: true, cwd: '../Source/iOS', src: ['**'], dest: 'Deploy/Debug/iOS'},
              {expand: true, cwd: 'Deploy/Debug/www', src: ['**'], dest: 'Deploy/Debug/iOS/www'},
            ],
        },
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
  grunt.registerTask('default', ['clean', 'copy:template', 'copy:iosDebug']);

};
