package com.market.place.domain.repository;

import com.market.place.domain.UserDomain;

import java.util.List;
import java.util.Optional;

public interface UserRepository {
    List<UserDomain> getAll();

    Optional<List<UserDomain>> getAllUsersActive(int active);
}
