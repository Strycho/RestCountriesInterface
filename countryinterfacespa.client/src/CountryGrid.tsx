import React from 'react';

function CountryGrid({ countries, searchText, onCountryClick }) {
  if (!countries) {
    return <div>Loading...</div>;
  }

  const filteredCountries = countries.filter(country => searchText === '' || (country.name.official ? 
    country.name.official.toLowerCase() : '').includes(searchText.toLowerCase()));

  return (
    <div className="flag-image-grid">
      {filteredCountries.map(country => (
        <div key={country.name.official} className="flag-image-grid-item" onClick={() => onCountryClick(country.name.official)}>
          <img src={country.flags.png} alt={country.name.official} />
        </div>
      ))}
    </div>
  );
}

export default CountryGrid;