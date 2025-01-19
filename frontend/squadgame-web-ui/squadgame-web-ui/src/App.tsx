import React, { useState } from 'react';
import SearchBox from './components/SearchBox';
import TeamList from './components/TeamList/TeamList';

const App: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchQuery, setSearchQuery] = useState('');
  const [league] = useState(39); 
  const [seasonYear] = useState(2023);  

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
  };

  const handleSearch = () => {
    if (!searchTerm.trim()) {
      setSearchQuery(''); 
    } else {
      setSearchQuery(searchTerm);
    }
  };


  return (
    <div style={{ padding: '20px' }}>
      <h1>Football Teams</h1>
      <SearchBox
        value={searchTerm}
        onChange={handleSearchChange}
        onSearch={handleSearch}
      />
      <TeamList searchTerm={searchQuery} league={league} seasonYear={seasonYear} />
    </div>
  );
};

export default App;
