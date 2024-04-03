import React, { useState, useEffect } from 'react';
import CountryGrid from './CountryGrid';
import CountryModal from './CountryModal';
import useFetch from './hooks/useFetch';
import useModal from './hooks/useModal';

function App() {
    const [darkMode, setDarkMode] = useState(false);
    const [searchText, setSearchText] = useState('');
    const { data: countries, fetchData: populateCountryData } = useFetch('country');
    const { modalVisible, modalClosing, openModal, closeModal, modalData, setModalData } = useModal();

    useEffect(() => {
        document.body.classList.toggle('dark-mode', darkMode);
        populateCountryData();
    }, [darkMode]);

    const handleSearchChange = (event) => {
        setSearchText(event.target.value);
    };

    const handleDarkModeChange = () => {
        setDarkMode(!darkMode);
    };

    const getCountryInfoforFlag = async (countryName) => {
        const response = await fetch(`/country/${countryName}`);
        const data = await response.json();
        setModalData(data);
        openModal();
    };

    return (
        <div className={darkMode ? 'background dark-mode' : 'background'}>
            <h1 id="tabelLabel">Country Interface</h1>
            <div className="toggle-switch">
                <input type="checkbox" id="darkModeSwitch" checked={darkMode} onChange={handleDarkModeChange} />
                <label htmlFor="darkModeSwitch">Dark Mode</label>
            </div>
            <input type="text" className='countryTextFilter' value={searchText} onChange={handleSearchChange} placeholder="Search for a country" />
            <CountryGrid countries={countries} searchText={searchText} onCountryClick={getCountryInfoforFlag} />
            <CountryModal visible={modalVisible} closing={modalClosing} onClose={closeModal} countryInfo={modalData} />
        </div>
    );
}

export default App;