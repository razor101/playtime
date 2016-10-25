module.exports = function (grunt) {

	grunt.initConfig({
		pkg: grunt.file.readJSON('package.json'),

		concat: {
			options: {
				separator: ';'
			},
			dist: {
				src: [
					'Scripts/jquery-2.1.1.min.js',
                    'Scripts/jquery.validate.min.js',
                    'Scripts/jquery.unobtrusive-ajax.min.js',
                    'Scripts/jquery.validate.unobtrusive.min.js',
                    'Scripts/bootstrap.js'
				],
				dest: 'Scripts/plugins.js'
			}
		},

		uglify: {
			options: {
				banner: '/*! <%= pkg.name %> <%= grunt.template.today("dd-mm-yyyy") %> */\n'
			},
			dist: {
				files: {
					'Scripts/plugins.min.js': ['Scripts/plugins.js'],
					'Scripts/main.min.js': ['Scripts/main.js']
				}
			}
		},
		
		sass: {
		    dev: {
		        options: {
		            sourcemap: 'none'
		        },
				files: {
				    "Content/Css/main.css": "Sass/main.scss"
				}
			},
			dist: {
				options: {
				    style: 'compressed',
				    sourcemap: 'none'
				},
				files: {
				    "Content/Css/main.min.css": "Sass/main.scss"
				}
			}
		},
		watch: {
			scripts: {
			    files: ['Scripts/main.js'],
				tasks: ['js']
			},
			css: {
				files: ['Sass/**/*.scss'],
				tasks: ['css']
			}
		}
	});

	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-watch');
	grunt.loadNpmTasks('grunt-contrib-sass');

	grunt.registerTask('js', ['concat', 'uglify']);
	grunt.registerTask('css', ['sass']);
	grunt.registerTask('default', ['concat', 'uglify', 'sass']);

};