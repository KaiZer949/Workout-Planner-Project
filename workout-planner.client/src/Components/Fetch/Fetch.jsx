const Fetch = (url)=> {
  return (
      await fetch(url, {
          method: "GET",
          headers: {
              "Content-Type": "application/json",
          },
      })
  );
}

export default Fetch;