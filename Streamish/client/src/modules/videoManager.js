const baseUrl = '/api/video';

export const getAllVideos = () => {
  return fetch(baseUrl)
    .then((res) => res.json())
};

export const addVideo = (video) => {
  return fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(video),
  });
};

export const getAllWithComments = () => {
    return fetch(baseUrl + '/GetWithComments')
        .then((res) => res.json())
};

const searchVideosEndpoint = baseUrl + "/search";
export const SearchVideos = (searchText) => {
    return fetch(searchVideosEndpoint + "/?s=" + searchText + "&sortDesc=true")
    .then((res) => res.json());    
};