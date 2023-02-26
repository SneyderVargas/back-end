package com.market.place.domain.repository;

import com.market.place.domain.UserDomain;

import java.util.List;

public interface UserRepository {
    List<UserDomain> getAll();
}
