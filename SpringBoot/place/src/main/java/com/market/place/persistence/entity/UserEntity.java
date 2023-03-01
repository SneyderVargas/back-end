package com.market.place.persistence.entity;

import javax.persistence.*;

@Entity
@Table(name = "users", schema = "adm")
public class UserEntity {
    @Id
    private Long id;
    private String name;
    private String surname;
    private int active;

    public int getActive() {
        return active;
    }

    public void setActive(int active) {
        this.active = active;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }
}
