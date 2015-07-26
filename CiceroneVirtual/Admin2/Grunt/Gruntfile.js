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
              {expand: true, cwd: '../../../Comum/js', src: ['ciceroneVirtual.js'], dest: '../Source/Template/js', filter: 'isFile'},
              {expand: true, cwd: '../Source/Template/assets', src: ['**'], dest: '../Debug/assets'},
              {expand: true, cwd: '../Source/Template/css', src: ['**'], dest: '../Debug/css'},
              {expand: true, cwd: '../Source/Template/img', src: ['**'], dest: '../Debug/img'},
              {expand: true, cwd: '../Source/Template/js', src: ['**'], dest: '../Debug/js'},
              {expand: true, cwd: '../Source/Template/JS-SDK-0.8.4', src: ['**'], dest: '../Debug/JS-SDK-0.8.4'},
              {expand: true, cwd: '../Source/Pages', src: ['Login.html'], dest: '../Debug', filter: 'isFile'},
            ],
        },
    },
    includes: {
        files:{
            src:['../Source/Pages/main.html', 
                 '../Source/Pages/beacons_list.html',
                 '../Source/Pages/beacons_detail.html',
                 '../Source/Pages/obras_list.html',
                 '../Source/Pages/obras_detail.html',
                 '../Source/Pages/comentarios_list.html',
                ],
            dest: '../Debug',
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
  grunt.registerTask('default', ['clean', 'copy:template', 'includes']);

};
