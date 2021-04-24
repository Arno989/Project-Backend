# Project Backend
Movie database API based on Popcorn time and IMDB  
***Sources:***  
https://www.reddit.com/r/PopCornTimeApp/comments/ku1vru/look_popcorntime_is_awesome_but_the_movies_wont/  
https://popcornofficial.docs.apiary.io/#reference/movie/get-page/page?console=1  
https://popcorntime.api-docs.io/api/movie/FugRpgn5f3wjWSduF  
https://yts.mx/api  

## Endpoints:
Movie:  
**GET**&emsp; &emsp; &emsp; - /movies  
**GET**&emsp; &emsp; &emsp; - /movie/{id}  
**POST**&emsp; &emsp; &nbsp; - /movie  

Actor:  
**GET**&emsp; &emsp; &emsp; - /actors  
**GET**&emsp; &emsp; &emsp; - /actor/{id}  
**POST**&emsp; &emsp; &nbsp; - /actor  

Torrent:  
**GET**&emsp; &emsp; &emsp; - /torrent/{movie id}  
**POST**&emsp; &emsp; &nbsp; - /torrent/{movie id}  

## Objects:

Movie:
- Imdb id	    (string)
- Name		    (string)
- Runtime	    (int)
- Release date	(datetime)
- Synopsis	    (string)
- List(Genre)
- Rating	    (double)
- Trailer	    (string)
- List(Actor)
- List(Torrent)
  
Actor:
- imdb id	    (string)
- Name		    (string)
- Age		    (int)
- List(Movie)
  
Torrent:
- Magnet link 	(string)
- Movie id 	    (string)
- Quality 	    (string)
- Seeds 	    (int)
- Peers 	    (int)
- Filesize 	    (string)