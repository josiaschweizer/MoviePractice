namespace MoviePractice.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open MoviePractice.Library
open MoviePractice.Library.MovieService.MovieService

[<TestClass>]
type TestMovieService() =

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
    member this.TestGetTitles_1() =
        let result = getTitles movies

        CollectionAssert.AreEqual([| "Titel"; "Neu" |], result |> List.toArray)

    [<TestMethod>]
    member this.TestGetTitles_2() =
        let testMovies: Movie list = []
        let result = getTitles testMovies

        CollectionAssert.AreEqual([||], result |> List.toArray)
