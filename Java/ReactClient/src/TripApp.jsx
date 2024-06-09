import TripForm from "./TripForm.jsx";
import TripTable from "./TripTable.jsx";

import {useState} from "react";
import {AddTrip, GetTrips, DeleteTrip, UpdateTrip} from "./utils/rest-calls.js";

export default function TripApp() {
    const [trips, setTrips] = useState([{'id': 'test', 'landmark': 'test', 'transportCompanyName': 'test', 'departureTime': 'test', 'price': 'test', 'availableSeats': 'test'}]);
    // const [trips, setTrips] = useState([]);
    // GetTrips().then(res => setTrips(res))
    //     .catch(error => console.log("Eroare la obtinerea Trip-urilor: ", error));

    function addFunction(trip) {
        AddTrip(trip)
            .then(res => GetTrips())
            .then(receivedTrips => setTrips(receivedTrips))
            .catch(error => console.log('Erroare la adaugare: ', error));
    }

    function deleteFunction(id) {
        DeleteTrip(id)
            .then(response => GetTrips())
            .then(receivedTrips => setTrips(receivedTrips))
            .catch(error => console.log('Erorare la stergere: ', error));
    }

    function updateFunction(trip) {
        UpdateTrip(trip)
            .then(response => GetTrips())
            .then(receivedTrips=> setTrips(receivedTrips))
            .catch(error => console.log('Eroare la update: ', error));
    }

    return (
        <div className="TripApp">
            <h1>Trips management</h1>
            <TripForm addFunction={addFunction} />
            <br/><br/>
            <TripTable tripList={trips} deleteFunction={deleteFunction} updateFunction={updateFunction} />
        </div>
    );
}