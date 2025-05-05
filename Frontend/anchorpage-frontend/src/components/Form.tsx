function Form() {
  const cities = ["New York", "London", "San Francisco", "Paris", "Amsterdam"];

  return (
    <>
      <ul>
        {cities.map(city => <li key={city}>{city}</li>)}
      </ul>
    </>
  )
}

export default Form;