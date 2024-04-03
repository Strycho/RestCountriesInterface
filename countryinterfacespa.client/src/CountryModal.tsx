import React from 'react';

function CountryModal({ visible, closing, countryInfo, onClose }) {
    if (!visible) {
        return null;
    }

    return (
        <div className={`modal ${closing ? 'modal-closing' : 'modal-open'}`}>
            <div className="modal-content">
                {countryInfo ? (countryInfo.map(countryInfo => (
                        <div>
                            <h1>{countryInfo.name.official}</h1>
                            <p>Capital: {Object.values(countryInfo.capital).join(', ')}</p>
                            <p>Currencies: {Object.values(countryInfo.currencies).map(currency => `${currency.name} (${currency.symbol})`).join(', ')}</p>
                            <p>Population: {countryInfo.population}</p>
                            <p>3 digit ISO code: {countryInfo.cca3}</p>
                            <p>Languages: {Object.values(countryInfo.languages).join(', ')}</p>
                        </div>
                    ))): (
                    <div>Loading...</div>
                )}
                <button onClick={onClose}>Close</button>
            </div>
        </div>
    );
}

export default CountryModal;