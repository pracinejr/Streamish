import React, { useEffect, useState, useRef } from "react";
import Video from './Video';
import { SearchVideos, getAllWithComments } from "../modules/videoManager";


const VideoList = () => {
  const [videos, setVideos] = useState([]);
  
  const [ searchTerms, setSearchTerms ] = useState("");

//   const handleOnChange = (event) => setSearchTerms(event.target.value);


  const getVideos = () => {
      getAllWithComments().then(videos => setVideos(videos));
  };

  
    const handleSearch = (event) => {
        setSearchTerms(event.target.value)
          SearchVideos(searchTerms)
          .then((searchResults) => setVideos(searchResults));
      }
  

  useEffect(() => {
    getVideos();
  }, []);

  return (
      <>
      <div>
      Video Search:
      <input
        type="text"
        // ref="textInput"
        className="input--wide"
        onChange={handleSearch}
        placeholder="Search For Videos Here..."
        value={searchTerms}
        />
        </div>
    <div className="container">
      <div className="row justify-content-center">
        {videos.map((video) => (
          <Video video={video} key={video.id} />
        ))}
      </div>
    </div>
    </>
  );
};

export default VideoList;
