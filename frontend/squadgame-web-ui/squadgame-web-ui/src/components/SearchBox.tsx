import React from 'react';

interface SearchBoxProps {
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSearch: () => void;
}


const SearchBox: React.FC<SearchBoxProps> = ({ value, onChange, onSearch }) => {
  const handleKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') {
      onSearch();
    }
  };

  return (
    <input
      type="text"
      placeholder="Search teams..."
      value={value}
      onChange={onChange}
      onKeyDown={handleKeyDown}
      style={{
        width: '100%',
        padding: '10px',
        fontSize: '16px',
        marginBottom: '20px',
        border: '1px solid #ccc',
        borderRadius: '4px',
      }}
    />
  );
};

export default SearchBox;