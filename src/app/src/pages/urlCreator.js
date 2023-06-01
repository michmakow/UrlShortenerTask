import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { isValidUrl } from "../utils/isValidUrl";

export const UrlCreator = () => {
  const [longUrl, setLongUrl] = useState("");
  const [shortUrl, setShortUrl] = useState("");
  let navigate = useNavigate();

  const submitHandler = async (event) => {
    event.preventDefault();

    if (isValidUrl(longUrl)) {
      var options = {
        method: "POST",
        headers: {
          "Content-type": "application/json",
        },
        body: JSON.stringify({ longUrl: longUrl }),
      };

      await fetch(`http://localhost:5167/`, options)
        .then((response) => {
          return response.text();
        })
        .then((response) => {
          if (response) {
            setShortUrl(response);
          } else {
            console.log(response.reason);
          }
        })
        .catch((reason) => {
          console.log(reason);
        });
    } else {
      alert("Please enter a valid url");
    }
  };

  const changeHandler = (event) => {
    setLongUrl(event.target.value);
  };

  const routeHandler = () => {
    navigate("/url-list");
  };

  return (
    <React.Fragment>
      <form onSubmit={submitHandler}>
        <input type="text" placeholder="pass url" onChange={changeHandler} />
        <button>submit</button>
        <p>{shortUrl}</p>
      </form>
      <button type="text" placeholder="Url List" onClick={routeHandler}>
        Url List
      </button>
    </React.Fragment>
  );
};

export default UrlCreator;
