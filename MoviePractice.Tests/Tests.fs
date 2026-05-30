namespace MoviePractice.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open Xunit
open MoviePractice.Library
open MoviePractice.Library.MovieService.MovieService

[<TestClass>]
module TestMovieService() =

    let movies: Movie list =
        [ { Title = "Titel"
            Year = 2018
            Rating = 7.1
            Duration = 96
            Genres = [ "Action"; "Sci-Fi" ]
            IsStreaming = true }
          { Title = "Neu"
            Year = 2025
            Rating = 9.1
            Duration = 124
            Genres = [ "Action" ]
            IsStreaming = false } ]

    [<TestMethod>]
    let testGetTitles_1 () =
        let result = getTitles movies

        Assert.Equal<string list>([ "Titel"; "Neu" ], result)

    [<TestMethod>]
    let testGetTitles_2 () =
        let testMovies: Movie list = []
        let result = getTitles testMovies

        Assert.Equal<string list>([], result)
