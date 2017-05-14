/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/
'use strict';

var gulp        = require('gulp'),
    typescript  = require('typescript'),
    ts          = require('gulp-typescript'),
    gulpTypings = require("gulp-typings"),
    browserify  = require('browserify'),
    source      = require('vinyl-source-stream'),
    del         = require('del');

var tsProject = ts.createProject('scripts/tsconfig.json');

var paths = {
    scripts: ['scripts/**/*.tsx', 'scripts/**/*.ts', 'scripts/**/*.map'],
};

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task("installTypings",function(){
    var stream = gulp.src("./typings.json")
        .pipe(gulpTypings()); //will install all typingsfiles in pipeline. 
    return stream; // by returning stream gulp can listen to events from the stream and knows when it is finished. 
});

gulp.task('compile', ['installTypings'], function () {
    var tsResult = gulp.src(paths.scripts).pipe(tsProject());

    return tsResult.js.pipe(gulp.dest('wwwroot/scripts'));
});

gulp.task('bundle', ['compile'], function () {
  var b = browserify('wwwroot/scripts/app.js');
  return b.bundle()
    .pipe(source('bundle.js'))
    .pipe(gulp.dest('wwwroot/scripts'));
});