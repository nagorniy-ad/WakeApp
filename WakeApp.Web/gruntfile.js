module.exports = function (grunt) {
    grunt.initConfig({
        copy: {
            build: {
                files: [
                    {
                        cwd: 'node_modules/jquery/dist/',
                        src: 'jquery.min.js',
                        dest: 'wwwroot/js/libs/jquery/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/bootstrap/dist/js/',
                        src: 'bootstrap.min.js',
                        dest: 'wwwroot/js/libs/bootstrap/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/bootstrap/dist/js/',
                        src: 'bootstrap.min.js.map',
                        dest: 'wwwroot/js/libs/bootstrap/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/noty/lib/',
                        src: 'noty.min.js',
                        dest: 'wwwroot/js/libs/noty/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/noty/lib/',
                        src: 'noty.min.js.map',
                        dest: 'wwwroot/js/libs/noty/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/bootstrap/dist/css/',
                        src: 'bootstrap.min.css',
                        dest: 'wwwroot/css/libs/bootstrap/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/bootstrap/dist/css/',
                        src: 'bootstrap.min.css.map',
                        dest: 'wwwroot/css/libs/bootstrap/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/noty/lib/',
                        src: 'noty.css',
                        dest: 'wwwroot/css/libs/noty/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/noty/lib/',
                        src: 'noty.css.map',
                        dest: 'wwwroot/css/libs/noty/',
                        expand: true,
                        flatten: true
                    },
                    {
                        cwd: 'node_modules/noty/lib/themes/',
                        src: 'semanticui.css',
                        dest: 'wwwroot/css/libs/noty/themes/',
                        expand: true,
                        flatten: true
                    }
                ]
            }
        }
    });
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.registerTask('build', ['copy']);
};