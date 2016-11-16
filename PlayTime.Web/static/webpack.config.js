var webpack = require('webpack');

module.exports = {
	entry: './src/js/main.js',
	output: {
		path: './dist/js',
		filename: 'main.min.js'
	},
	plugins: [
		new webpack.optimize.UglifyJsPlugin({
			compress: {
				warnings: false
			},
			output: {
				comments: false
			}
		})
	]
};