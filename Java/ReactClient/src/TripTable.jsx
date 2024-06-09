import './TripTable.css'
import ModalWindow from "./Modal-Window.jsx";
import {useState} from "react";

function TripRow({trip, deleteFunction, updateFunction}) {
    const [modalOpen, setModalOpen] = useState(false);
    function handleDelete(event) {
        deleteFunction(trip.id);
    }

    function handleUpdate(event) {
        setModalOpen(true);
    }

    return (
        <tr>
            <td>{trip.id}</td>
            <td>{trip.landmark}</td>
            <td>{trip.transportCompanyName}</td>
            <td>{trip.departureTime}</td>
            <td>{trip.price}</td>
            <td>{trip.availableSeats}</td>
            <td>
                <div className="buttonsCell">
                    <button className="actionRowButton" onClick={handleUpdate}>Update</button>
                    { modalOpen && <ModalWindow trip={trip} updateFunction={updateFunction} closeModal={() => setModalOpen(false)}/>}
                    <button className="actionRowButton" onClick={handleDelete}>Delete</button>
                </div>
            </td>
        </tr>
    );
}

export default function TripTable({tripList, deleteFunction, updateFunction}) {
    let rows = []
    let deleteFunc = deleteFunction;
    let updateFunc = updateFunction;

    tripList.forEach(function (trip) {
        rows.push(<TripRow trip={trip} key={trip.id} deleteFunction={deleteFunc} updateFunction={updateFunc} />);
    });

    return (
        <div className="tripTableContainer">

            <table className="tripTable">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Landmark</th>
                    <th>Company name</th>
                    <th>Departure date</th>
                    <th>Price</th>
                    <th>Available seats</th>
                    <th>Actions</th>
                </tr>
                </thead>

                <tbody>{rows}</tbody>
            </table>

        </div>
    );
}