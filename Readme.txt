GetAllMovies -- Get all movies list 
API: GET http://localhost:52640/api/Movie/GetAllMovies
Sample Response
 {
    {
    "movieId": "7b52d2f9-b741-41e3-9562-91dab4141ddb",
    "movieName": "Tiger Zinda Hai",
    "description": "RAW Agent Tiger joins forces with Zoya in order to rescue a group of nurses who are held hostage by a terrorist organisation.",
    "dateOfRelease": "2017-12-22T00:00:00",
    "moviePoster": null,
    "producer": {
      "producerId": "7f0c1ce0-6157-4423-ac57-5e2dd50ca61a",
      "producerName": "Aditya Chopra"
      },
    "movieActors": [
      {
      "actorId": "c59f8138-6fc4-4f7d-a221-c0fe72be17d0",
      "actorName": "Salman Khan"
      },
      {
      "actorId": "fe697bc6-3ebf-411b-94ee-c20c4301bf6d",
      "actorName": "Katrina Kaif"
      },
      {
      "actorId": "0e1858a9-1538-4c76-9821-c7154da25722",
      "actorName": "Paresh Rawal"
      },
    ]
   },
   {
    "movieId": "6dd00b53-2821-4819-9c4c-69988bf6c187",
    "movieName": "Holiday",
    "description": "Virat Bakshi (Akshay Kumar), Captain in DIA, a secret wing of Indian Army, returns to his home in Mumbai on a holiday. On his arrival, his parents rush him to see Saiba Thapar (Sonakshi Sinha), who they wanted him to marry. But Virat rejects her with an excuse that she is old fashioned and not his type.",
    "dateOfRelease": "2014-06-06",
    "moviePoster": null,
    "producer": {
      "producerId": "e95d23a8-1309-49dc-83d2-99046d58f2f8",
      "producerName": "Arun Bhatiya"
      },
    "movieActors": [
      {
      "actorId": "ad730394-4702-4522-bfb9-6c8c8e919a26",
      "actorName": "Akshay Kumar"
      },
      {
      "actorId": "6df0b07b-e4e0-4109-98bf-815a8e7c66d4",
      "actorName": "Sonakshi Sinha"
      },
      {
      "actorId": "9e3ddd4b-5cca-474d-899d-7f5093207be2",
      "actorName": "Govinda"
      },
    ]
   }
 }


Create movie-- create a new  movie and add in DB
API: POST http://localhost:52640/api/Movie
Sample Request body
{
  "movieId": null,
  "movieName": "Tiger Zinda Hai"
  "movieDescription": "RAW Agent Tiger joins forces with Zoya in order to rescue a group of nurses who are held hostage by a terrorist organisation.",
  "dateOfRelease": "2017-12-22T00:00:00",
  "producerId": "7f0c1ce0-6157-4423-ac57-5e2dd50ca61a",
  "actorIds": ["c59f8138-6fc4-4f7d-a221-c0fe72be17d0","fe697bc6-3ebf-411b-94ee-c20c4301bf6d","0e1858a9-1538-4c76-9821-c7154da25722"],
  "poster": null
}

Edit movi -- update existing movie
API: PUT http://localhost:52640/api/Movie
Sample Request body
{
  "movieId": "7b52d2f9-b741-41e3-9562-91dab4141ddb",
  "movieName": "Tiger Zinda Hai"
  "movieDescription": "RAW Agent Tiger joins forces with Zoya in order to rescue a group of nurses who are held hostage by a terrorist organisation.",
  "dateOfRelease": "2017-12-22T00:00:00",
  "producerId": "7f0c1ce0-6157-4423-ac57-5e2dd50ca61a",
  "actorIds": ["c59f8138-6fc4-4f7d-a221-c0fe72be17d0","fe697bc6-3ebf-411b-94ee-c20c4301bf6d","0e1858a9-1538-4c76-9821-c7154da25722"],
  "poster": null
}
