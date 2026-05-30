open System
open MoviePractice.Library
open MoviePractice.Library.MovieService.MovieService

let movies: Movie list =
    [ { Title = "Skybound"
        Year = 2018
        Rating = 7.8
        Duration = 124
        Genres = [ "Action"; "Sci-Fi" ]
        IsStreaming = true }
      { Title = "Silent River"
        Year = 2020
        Rating = 8.4
        Duration = 98
        Genres = [ "Drama"; "Mystery" ]
        IsStreaming = false }
      { Title = "Neon Nights"
        Year = 2022
        Rating = 6.9
        Duration = 110
        Genres = [ "Thriller"; "Action" ]
        IsStreaming = true }
      { Title = "Forest Tales"
        Year = 2016
        Rating = 7.2
        Duration = 86
        Genres = [ "Family"; "Adventure" ]
        IsStreaming = true }
      { Title = "Code Red"
        Year = 2021
        Rating = 8.1
        Duration = 132
        Genres = [ "Action"; "Drama" ]
        IsStreaming = false }
      { Title = "The Last Orbit"
        Year = 2019
        Rating = 9.0
        Duration = 141
        Genres = [ "Sci-Fi"; "Adventure"; "Drama" ]
        IsStreaming = true }
      { Title = "Small Steps"
        Year = 2015
        Rating = 6.5
        Duration = 92
        Genres = [ "Drama" ]
        IsStreaming = false }
      { Title = "Hidden Signal"
        Year = 2023
        Rating = 7.6
        Duration = 105
        Genres = [ "Mystery"; "Sci-Fi" ]
        IsStreaming = true } ]

let menu () : string =
    printfn "Movie Analyzer"
    printfn "Please select an option:"

    printfn "1. Show all movies"
    printfn "2. Filter by genre"
    printfn "3. Filter by year"
    printfn "4. Get by minimum rating"
    printfn "5. Get by maximum duration"
    printfn "6. Get by streaming availability"
    printfn "7. Show movies with rating over 8.0"
    printfn "8. Show best rated movie"
    printfn "9. Sort movies by rating"
    printfn "10. Count genres per movie"
    printfn "11. Search movie by title"
    printfn "12. Calculate average rating"
    printfn "0. Exit"

    Console.ReadLine()

let printMovie movie (newLine: bool) =
    let genresText = movie.Genres |> String.concat ", "

    let toPrint =
        sprintf "%s (%d) - Rating: %.1f - Genres: %s" movie.Title movie.Year movie.Rating genresText

    if newLine then
        printfn $"%s{toPrint}"
    else
        printf $"%s{toPrint}"

let printMovieNewLine movie = printMovie movie true

let handleFilterByGenre () =
    let genres = getGenres movies
    printfn "Filter by genre"
    printfn "Available genres:"
    genres |> List.iter (fun g -> printfn $"- %s{g}")

    printf "Enter genre: "
    let selectedGenre = Console.ReadLine()

    if genres |> List.contains selectedGenre then
        let movies = getMoviesByGenre movies selectedGenre
        movies |> List.iter (fun m -> printMovieNewLine m)
    else
        printfn "Genre %s nicht gefunden" selectedGenre

let handleFilterByYear () =
    let years = getYears movies
    printfn "Filter by Year"
    printfn "Available years:"
    years |> List.iter (fun y -> printfn $"- %d{y}")

    printfn "Enter Year: "
    let selectedYear = Console.ReadLine()

    match Int32.TryParse(selectedYear) with
    | true, selectedYear ->
        if years |> List.contains selectedYear then
            let filteredMovies = getMoviesByYear movies selectedYear
            filteredMovies |> List.iter (fun m -> printMovieNewLine m)
    | false, _ -> printfn "Please enter a valid year."

let handleSearchMovie () : Movie list =
    printf "Enter the phrase you wanna search for: "
    let searchQuery = Console.ReadLine()

    getMovieBySearchPhrase movies searchQuery


let input = menu ()

match input with
| "1" ->
    printfn "All Movies:"

    movies |> List.iter (fun x -> printMovie x true)
| "2" -> handleFilterByGenre ()
| "3" -> handleFilterByYear ()
| "4" ->
    let shortestMovie = getMovieByShortestDuration movies
    printMovieNewLine shortestMovie
| "5" ->
    let longestMovie = getMovieByLongestDuration movies
    printMovieNewLine longestMovie
| "6" ->
    let streamingAvailability = getMoviesWithStreamingAvailability movies
    streamingAvailability |> List.iter (fun m -> printMovieNewLine m)
| "7" ->
    let moviesRaitingOverEight = getMoviesRaitingOver movies 8.0
    moviesRaitingOverEight |> List.iter (fun m -> printMovieNewLine m)
| "8" -> movies |> getBestRatedMovie |> printMovieNewLine
| "9" ->
    let moviesSortByRating = getMoviesSortedByRaiting movies
    moviesSortByRating |> List.iter (fun m -> printMovieNewLine m)
| "10" ->
    movies
    |> getGenresCountByMovie
    |> List.iter (fun (title, genreCount) -> printfn "%s: %d" title genreCount)
| "11" -> handleSearchMovie () |> List.iter (fun m -> printMovieNewLine m)
| "12" ->
    let average = calculateAverageRaiting movies
    printfn "Average Film Raiting: %f" average
| "0" -> printfn "Goodbye"
| _ -> printfn "Invalid option"
