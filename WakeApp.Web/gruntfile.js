/// <binding BeforeBuild='build' />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: [
            'wwwroot/js/bundle.js',
            'wwwroot/css/bundle.css'
        ],
        concat: {
            build: {
                src: [
                    'node_modules/jquery/dist/jquery.min.js',
                    'node_modules/noty/lib/noty.min.js',
                    'Scripts/notifier.js',
                    'Scripts/wolclient.js',
                    'Scripts/init.js'
                ],
                dest: 'wwwroot/js/bundle.js'
            }
        },
        cssmin: {
            build: {
                files: {
                    'wwwroot/css/bundle.css': [
                        'node_modules/bootstrap/dist/css/bootstrap.css',
                        'node_modules/noty/lib/noty.css',
                        'node_modules/noty/lib/themes/semanticui.css'
                    ]
                }
            }
        }
    });
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.registerTask('build', ['clean','concat', 'cssmin']);
};