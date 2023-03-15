package com.market.place.domain.repository;

import com.market.place.domain.UserDomain;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.List;
import java.util.Optional;

public interface UserRepository {
    List<UserDomain> getAll();
    Optional<List<UserDomain>> getAllUsersActive(int active);
    UserDomain save(UserDomain userDomain);
    Page<UserDomain> getPagination(Pageable pageable);
}
