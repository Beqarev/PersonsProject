import React, {useEffect, useState} from 'react'

const apiURL = "https://localhost:7127/api/person";


const App = () => {

    const [persons, setPersons] = useState([])

    useEffect(() => {
        fetch(apiURL)
            .then(response => response.json())
            .then(data => {
                console.log('data', data);
                setPersons(data)
            })
            .catch(error => console.error('Error fetching data:', error));
    }, [])


    const handleFormSubmit = (event) => {
        event.preventDefault();

        const requestOptions = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                firstName: document.getElementById('firstName').value,
                lastName: document.getElementById('lastName').value,
                age: document.getElementById('age').value,
                email: document.getElementById('email').value,
                phoneNumber: document.getElementById('phoneNumber').value
            })
        };

        fetch(apiURL, requestOptions)
            .then(response => response.json())
            .then(newPerson => {
                setPersons(prevPersons => [...prevPersons, newPerson]);
            })
            .catch(error => console.error('Error submitting data:', error));
    }



    return (
        <div>
            <table>
                <thead>
                <tr>
                    <th>Firstname</th>
                    <th>Lastname</th>
                    <th>Age</th>
                    <th>Email</th>
                    <th>Phone Number</th>
                </tr>
                </thead>
                <tbody id="personData">
                {persons?.map(person => <tr>
                        <td>{person?.firstName}</td>
                        <td>{person?.lastName}</td>
                        <td>{person?.age}</td>
                        <td>{person?.email}</td>
                        <td>{person?.phoneNumber}</td>
                    </tr>
                )}
                </tbody>
            </table>
            <br/>
            <form onSubmit={handleFormSubmit}>
                <div>
                    <label For="firstName">First Name:</label>
                    <input type="text" id="firstName" name="firstName" />
                </div>
                <div>
                    <label For="lastName">Last Name:</label>
                    <input type="text" id="lastName" name="lastName" />
                </div>
                <div>
                    <label For="age">Age:</label>
                    <input type="text" id="age" name="age" />
                </div>
                <div>
                    <label For="email">Email:</label>
                    <input type="text" id="email" name="email" />
                </div>
                <div>
                    <label For="phoneNumber">Phone Number:</label>
                    <input type="text" id="phoneNumber" name="phoneNumber" />
                </div>
                <button type="submit">Add Person</button>
            </form>
        </div>

    )
}

export default App;
