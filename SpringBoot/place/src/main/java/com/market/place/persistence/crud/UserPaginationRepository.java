package com.market.place.persistence.crud;

import com.market.place.persistence.entity.UserEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserPaginationRepository extends JpaRepository<UserEntity, Long> {

}
