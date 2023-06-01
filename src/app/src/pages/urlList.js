import React, { useEffect, useState } from "react";

export const UrlList = () => {
  const [list, setList] = useState([])

  useEffect(()=> {
    getList();
  }, [])

  const getList = async () => {
    var options = {
      method: "GET",
      headers: {
        "Content-type": "application/json",
      },
    };

    await fetch(`http://localhost:5167/list`, options)
      .then((response) => {
        return response.json();
      })
      .then((response) => {
        setList(response);
        if (response) {
            setList(response);
        } else {
          console.log(response.reason);
        }
      })
      .catch((reason) => {
        console.log(reason);
      });
  };

  return (
    list && (
      <table className='url-list'>
        {list?.map((url) => (
          <tr>
            <td>
              <p>{url.longUrl}</p>
            </td>
            <td>
              <p>{url.shortUrl}</p>
            </td>
          </tr>
        ))}
      </table>
    )
  );
};

export default UrlList;
