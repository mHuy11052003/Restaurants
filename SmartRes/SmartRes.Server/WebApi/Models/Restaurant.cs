using System;
using System.Collections.Generic;

namespace SmartRes.Server.WebApi.Models;

public partial class Restaurant
{
    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? OpeningHours { get; set; }

    public string? CuisineType { get; set; }

    public double? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public byte? Status { get; set; }

    public string? Website { get; set; }

    public Guid? ManagerIdFk { get; set; }

    public int? SeatingCapacity { get; set; }

    public Guid RestaurantId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<LoyaltyProgram> LoyaltyPrograms { get; set; } = new List<LoyaltyProgram>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
