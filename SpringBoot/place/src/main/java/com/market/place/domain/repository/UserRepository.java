package com.market.place.domain.repository;

import com.market.place.domain.UserDomain;
import com.market.place.persistence.entity.UserEntity;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.List;
import java.util.Optional;

public interface UserRepository {
    Optional<UserDomain> getUser(int userId);
    List<UserDomain> getAll();
    Optional<List<UserDomain>> getAllUsersActive(int active);
    UserDomain save(UserDomain userDomain);
    Optional<Page<UserEntity>> getPagination(Pageable pageable);
    void delete(int userId);
}
