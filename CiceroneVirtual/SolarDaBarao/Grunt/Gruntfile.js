'use strict';

module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    // Metadata.
    
    pkg: grunt.file.readJSON('package.json'),
    clean: ["Debug/*", "Release/*"],
    copy: {
        template: {
            files: [
              // includes files within path
              {expand: true, cwd: '../../Comum/js', src: ['ciceroneVirtual.js'], dest: '../Source/Template/js', filter: 'isFile'},
              {expand: true, cwd: '../../Comum/js', src: ['ciceroneVirtual.js'], dest: '../Debug/www/js', filter: 'isFile'},
              {expand: true, cwd: '../Source/Template/fonts', src: ['**'], dest: '../Debug/www/fonts'},
              {expand: true, cwd: '../Source/Template/images', src: ['**'], dest: '../Debug/www/images'},
              {expand: true, cwd: '../Source/Template/libs', src: ['**'], dest: '../Debug/www/libs'},
              {expand: true, cwd: '../Source/Template/plugins', src: ['**'], dest: '../Debug/www/plugins'},
              {expand: true, cwd: '../Source/Template/ui', src: ['**'], dest: '../Debug/www/ui'},
              {expand: true, cwd: '../Source/Template/js', src: ['**'], dest: '../Debug/www/js'},
              {expand: true, cwd: '../Source/Template/JS-SDK-0.8.4', src: ['**'], dest: '../Debug/www/JS-SDK-0.8.4'},
              {expand: true, cwd: '../Source/Template', src: ['index.html'], dest: '../Debug/www', filter: 'isFile'},
            ],
        },
        iosDebug: {
            files: [
              // includes files within path
              {expand: true, cwd: '../Source/iOS', src: ['**'], dest: '../Debug/iOS'},
              {expand: true, cwd: '../Debug/www', src: ['**'], dest: '../Debug/iOS/www'},
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
