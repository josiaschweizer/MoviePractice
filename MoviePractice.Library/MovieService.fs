module MoviePractice.Library.MovieService

module MovieService =

    let getTitles (movies: Movie list) : string list = movies |> List.map (fun m -> m.Title)

    let getGenres (movies: Movie list) : string list =
        movies |> List.collect (fun m -> m.Genres) |> List.distinct

    let getYears (movies: Movie list) : int list = movies |> List.map (fun m -> m.Year)

    let getMoviesByGenre (movies: Movie list) (genre: string) : Movie list =
        let withSelectedGenre, withoutSelectedGenre =
            movies |> List.partition (fun movie -> movie.Genres |> List.contains genre)

        withSelectedGenre

    let getMoviesByYear (movies: Movie list) (year: int) : Movie list =
        movies |> List.filter (fun m -> m.Year = year)

    let getMovieByShortestDuration (movies: Movie list) : Movie =
        movies |> List.minBy (fun m -> m.Duration)

    let getMovieByLongestDuration (movies: Movie list) : Movie =
        movies |> List.maxBy (fun m -> m.Duration)

    let getMoviesWithStreamingAvailability (movies: Movie list) : Movie list =
        movies |> List.filter (fun m -> m.IsStreaming)

    let getMoviesRaitingOver (movies: Movie list) (raitingOver: float) =
        movies |> List.filter (fun m -> m.Rating >= raitingOver)

    let getBestRatedMovie (movies: Movie list) =
        movies |> List.maxBy (fun m -> m.Rating)

    let getMoviesSortedByRaiting (movies: Movie list) =
        movies |> List.sortBy (fun m -> m.Rating)

    let getGenresCountByMovie (movies: Movie list) : (string * int) list =
        movies |> List.map (fun movie -> movie.Title, movie.Genres.Length)

    let getMovieBySearchPhrase (movies: Movie list) (search: string) : Movie list =
        movies |> List.filter (fun m -> m.Title.Contains(search))

    let calculateAverageRaiting (movies: Movie list) : float =
        movies |> List.averageBy (fun m -> m.Rating)
