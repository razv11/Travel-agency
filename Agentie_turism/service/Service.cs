using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Agentie_turism.domain;
using Agentie_turism.repository.reservationRepo;
using Agentie_turism.repository.tripRepo;
using Agentie_turism.repository.userRepo;

namespace Agentie_turism.service;

public class Service
{
    private IUserRepository _userRepo;
    private ITripRepository _tripRepo;
    private IReservationRepository _reservationRepo;

    public Service(IUserRepository userRepository, ITripRepository tripRepository, IReservationRepository reservationRepository)
    {
        _userRepo = userRepository;
        _tripRepo = tripRepository;
        _reservationRepo = reservationRepository;
    }
    
    public static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    #nullable enable
    public User? AddUser(string username, string password)
    {
        User? user = _userRepo.FindUserByUsername(username);
        if (user is not null)
        {
            return null;
        }

        User newUser = new User(username, HashPassword(password));
        return _userRepo.Save(newUser);
    }

    public Boolean TryLogin(string username, string password)
    {
        User? user = _userRepo.FindUserByUsername(username);
        if (user is null)
        {
            return false;
        }

        if (user.Password.Equals(HashPassword(password)))
        {
            return true;
        }
        
        return false;
    }

    public IEnumerable<Trip> GetAllTrips()
    {
        return _tripRepo.FindAll();
    }

    public IEnumerable<Trip> GetFilteredTrips(string landmark, int startHour, int endHour)
    {
        return _tripRepo.FindBetweenHoursHavingLandmark(landmark, startHour, endHour);
    }

    public Reservation? SaveReservation(string clientName, string phoneNumber, int seats, string username, Trip trip)
    {
        User? user = _userRepo.FindUserByUsername(username);
        Reservation reservation = new Reservation(clientName, phoneNumber, seats, user, trip);
        trip.AvailableSeats = trip.AvailableSeats - seats;
        _tripRepo.Update(trip);
        return _reservationRepo.Save(reservation);
    }
    
    
}